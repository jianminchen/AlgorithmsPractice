using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumRootToLeftCsharp
{
    /**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
      public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
     }

    class SumRootToLeftCsharp
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(3); 

            int result = SumNumbers(root);
            Console.Write("Output is " + result); 
        }

        public static int SumNumbers(TreeNode root)
        {
            int res = 0;
            if (root == null) return res;

            dfs(root, 0, ref res);
            return res; 
        }

        public static void dfs(TreeNode root, int cur, ref int res)
        {
            TreeNode l = root.left;
            TreeNode r = root.right;
            if (l == null && r == null)
            {
                cur = cur * 10 + root.val;
                res += cur;
                return;
            }

            cur=cur*10+root.val;
            if(l!=null)
                dfs(l,cur, ref res);
            if(r!=null)
                dfs(r,cur, ref res);                 
        }
    }
}
