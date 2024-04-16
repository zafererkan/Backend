using Sobis.Core.Entities.Abstract;
using System;

namespace Sobis.Entities.ViewModels
{
    public class WindowParameter : IEntity
    {
        public Type Component { get; set; }
        public string WindowTitle { get; set; }
        public string MinWith { get; set; }
        public string MinHeight { get; set; }
        public bool CloseOnEscape { get; set; } = false;
    }
}
