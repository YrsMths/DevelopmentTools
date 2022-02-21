using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ToolsBaseClass.Base
{
    public interface IToolBaseInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// 工具名
        /// </summary>
        string ToolName { get; }

        string ToolDesc { get; }
        /// <summary>
        /// 窗口
        /// </summary>
        Window ToolWindow { get; }
        /// <summary>
        /// 图标
        /// </summary>
        ImageSource ToolIcon { get; }
        /// <summary>
        /// 作者
        /// </summary>
        string ToolAuthor { get; }
        /// <summary>
        /// 颜色
        /// </summary>
        Color ToolThemeColor { get; }
    }
}
