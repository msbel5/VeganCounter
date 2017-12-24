using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeganCounter.BLL.Dtos;

namespace VeganCounter.UI.ViewModels
{
    public class VeganFormViewModel
    {
        public VeganDto Vegan { get; set; }

        public string Title
        {
            get
            {
                if (Vegan != null && Vegan.Id != 0)
                    return "Edit Vegan";

                return "New Vegan";

            }
        }
    }
}