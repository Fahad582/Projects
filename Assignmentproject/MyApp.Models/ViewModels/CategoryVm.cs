using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class CategoryVm
    {
        public Category category { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
