using System.Linq;
using System.Windows.Forms;

namespace SimpleTreeView
{
    public static class SimpleTreeView
    {
        public static void CreateNode(TreeNodeCollection nodes ,string key, string[] direcciones,  char delimiter = '/')
        {
            TreeNode sistema = new TreeNode(key);
            sistema.Name = key;
            nodes.Add(sistema);

            foreach (var items in direcciones.OrderBy(x => x).ToArray())
            {
                int Indice = 0;
                var valores = items.Split(delimiter);
                foreach (var item in valores)
                {
                    if (item != "")
                    {
                        var x = GetNodes(nodes[key].Nodes, Indice);
                        if (!x.ContainsKey(item))
                            x.Add(new TreeNode(item) { Name = item });
                        Indice++;
                    }
                }
            }
        }

        private static TreeNodeCollection GetNodes(TreeNodeCollection Nodes, int Layerx)
        {
            int count = 0;
            TreeNodeCollection nodes;

            if (count == Layerx)
            {
                nodes = Nodes;
            }
            else
            {
                count++;
                nodes = GetNodes(Nodes[Nodes.Count - count].Nodes, Layerx - count);
            }

            return nodes;
        }
    }
}
