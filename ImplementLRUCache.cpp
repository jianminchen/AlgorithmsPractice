#include <stdio.h>
#include <stdlib.h>

// A queueu (Queue is implemented using Doubly linked list 
typedef struct QNode{
	struct QNode *prev, *next; 
	unsigned pageNumber; // the page number stored in this QNode
}QNode; 

// A queue (a FIFO collection of Queue Nodes)
typedef struct Queue{
	unsigned count; // number of filled frames
	unsigned numberOfFrames; // total number of frames
	QNode * front, *rear; 
}Queue; 

// A hash (collection of pointers to Queue Nodes)
typedef struct Hash
{
	int capacity; // how many pages can be there
	QNode** array;  // an array of queue nodes
}Hash; 

// A utility function to create a new Queue Node. The queue Node 
// will store the given 'pageNumber'
QNode* newQNode (unsigned pageNumber)
{
	//Allocate memory and assign 'pageNumber'
	QNode* temp = (QNode *) malloc (sizeof(QNode)); 
	temp->pageNumber = pageNumber; 

	//Initialize prev and next as NULL
	temp->prev = temp->next = NULL; 

	return temp; 
}

// A utility function to create an empty Queue.
// The queue can have at most 'numberOfFrames' nodes
Queue* createQueue(int numberOfFrames)
{
	Queue * queue = (Queue *)malloc (sizeof(Queue)); 

	// The queue is empty
	queue->count = 0; 
	queue->front = queue->rear = NULL;

	return queue; 

}

//  a utility function to create an empty Hash of given capacity
Hash* createHash(int capacity){
	//Allocate memory for hash
	Hash* hash = (Hash *) malloc(sizeof(Hash)); 
	hash->capacity	= capacity; 

	// Create an array of poiners for refering queue nodes
	hash->array = (QNode **) malloc(hash->capacity * sizeof(QNode*)); 

	// Initialize all hash entries as empty 
	int i; 
	for(i = 0; i < hash->capacity; ++i)
	{
		hash->array[i] = NULL; 
	}
	return hash; 
}


// A function to check if there is slot available in memory
int AreAllFramesFull( Queue* queue )
{
    return queue->count == queue->numberOfFrames;
}
 
// A utility function to check if queue is empty
int isQueueEmpty( Queue* queue )
{
    return queue->rear == NULL;
}
 
// A utility function to delete a frame from queue
void deQueue( Queue* queue )
{
    if( isQueueEmpty( queue ) )
        return;
 
    // If this is the only node in list, then change front
    if (queue->front == queue->rear)
        queue->front = NULL;
 
    // Change rear and remove the previous rear
    QNode* temp = queue->rear;
    queue->rear = queue->rear->prev;
 
    if (queue->rear)
        queue->rear->next = NULL;
 
    free( temp );
 
    // decrement the number of full frames by 1
    queue->count--;
}
 
// A function to add a page with given 'pageNumber' to both queue
// and hash
void Enqueue( Queue* queue, Hash* hash, unsigned pageNumber )
{
    // If all frames are full, remove the page at the rear
    if ( AreAllFramesFull ( queue ) )
    {
        // remove page from hash
        hash->array[ queue->rear->pageNumber ] = NULL;
        deQueue( queue );
    }
 
    // Create a new node with given page number,
    // And add the new node to the front of queue
    QNode* temp = newQNode( pageNumber );
    temp->next = queue->front;
 
    // If queue is empty, change both front and rear pointers
    if ( isQueueEmpty( queue ) )
        queue->rear = queue->front = temp;
    else  // Else change the front
    {
        queue->front->prev = temp;
        queue->front = temp;
    }
 
    // Add page entry to hash also
    hash->array[ pageNumber ] = temp;
 
    // increment number of full frames
    queue->count++;
}
 
// This function is called when a page with given 'pageNumber' is referenced
// from cache (or memory). There are two cases:
// 1. Frame is not there in memory, we bring it in memory and add to the front
//    of queue
// 2. Frame is there in memory, we move the frame to front of queue
void ReferencePage( Queue* queue, Hash* hash, unsigned pageNumber )
{
    QNode* reqPage = hash->array[ pageNumber ];
 
    // the page is not in cache, bring it
    if ( reqPage == NULL )
        Enqueue( queue, hash, pageNumber );
 
    // page is there and not at front, change pointer
    else if (reqPage != queue->front)
    {
        // Unlink rquested page from its current location
        // in queue.
        reqPage->prev->next = reqPage->next;
        if (reqPage->next)
           reqPage->next->prev = reqPage->prev;
 
        // If the requested page is rear, then change rear
        // as this node will be moved to front
        if (reqPage == queue->rear)
        {
           queue->rear = reqPage->prev;
           queue->rear->next = NULL;
        }
 
        // Put the requested page before current front
        reqPage->next = queue->front;
        reqPage->prev = NULL;
 
        // Change prev of current front
        reqPage->next->prev = reqPage;
 
        // Change front to the requested page
        queue->front = reqPage;
    }
}
 
// Driver program to test above functions
int main()
{
    // Let cache can hold 4 pages
    Queue* q = createQueue( 4 );
 
    // Let 10 different pages can be requested (pages to be
    // referenced are numbered from 0 to 9
    Hash* hash = createHash( 10 );
 
    // Let us refer pages 1, 2, 3, 1, 4, 5
    ReferencePage( q, hash, 1);
    ReferencePage( q, hash, 2);
    ReferencePage( q, hash, 3);
    ReferencePage( q, hash, 1);
    ReferencePage( q, hash, 4);
    ReferencePage( q, hash, 5);
 
    // Let us print cache frames after the above referenced pages
    printf ("%d ", q->front->pageNumber);
    printf ("%d ", q->front->next->pageNumber);
    printf ("%d ", q->front->next->next->pageNumber);
    printf ("%d ", q->front->next->next->next->pageNumber);

	getchar();
 
    return 0;
}




