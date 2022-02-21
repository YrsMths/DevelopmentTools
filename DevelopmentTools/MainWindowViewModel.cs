using DevelopentTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ToolsBaseClass;
using ToolsBaseClass.Base;

namespace DevelopmentTools
{
    class MainWindowViewModel
    {
        public MainWindow window;
        public BindingList<ToolModel> tools { get; set; }
        public MainWindowExitCommand exit { get; set; } = new MainWindowExitCommand();

        public MainWindowViewModel()
        {
            tools = new BindingList<ToolModel>();
            window = new MainWindow();
            Type[] types = GetTypesInNamespace(Assembly.Load("ToolsLibrary"), "ToolsLibrary");
            Dictionary<string, List<Type>> dic = new Dictionary<string, List<Type>>();
            foreach (Type type in types)
            {
                if (dic.Keys.Contains(type.Namespace))
                {
                    dic[type.Namespace].Add(type);
                }
                else
                {
                    dic.Add(type.Namespace, new List<Type>() { type });
                }
            }
            foreach (var pair in dic)
            {
                foreach (Type type in pair.Value)
                {
                    if (type.GetInterface("IToolBaseInfo") != null)
                    {
                        ToolModel tool = new ToolModel();
                        tool.ToolType = type;
                        IToolBaseInfo obj = (IToolBaseInfo)Activator.CreateInstance(type);
                        tool.ToolName = obj.ToolName;
                        tool.ToolDesc = obj.ToolDesc;
                        tool.ToolIcon = obj.ToolIcon;
                        tool.ToolAuthor = obj.ToolAuthor;
                        tool.BackgroundBrush = new System.Windows.Media.SolidColorBrush(obj.ToolThemeColor);
                        tool.ForegroundBrush = new SolidColorBrush(GetForegroundColor(obj.ToolThemeColor));
                        tool.instance = obj;
                        tools.Add(tool);
                    }
                }
            }
            window.DataContext = this;
            window.Show();
        }

        private Color GetForegroundColor(Color Bgcolor)
        {
            var Y = 0.299 * Bgcolor.R + 0.587 * Bgcolor.G + 0.114 * Bgcolor.B;
            if (Y > 130)
            {
                return Color.FromRgb(0, 0, 0);
            }
            else
            {
                return Color.FromRgb(255, 255, 255);
            }
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains(nameSpace)).ToArray();
        }
    }
}
