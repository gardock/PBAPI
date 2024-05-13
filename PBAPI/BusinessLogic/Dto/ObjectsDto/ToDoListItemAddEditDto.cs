using DB.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto.ObjectsDto
{
    public class ToDoListItemAddEditDto
    {
        //TODO wymagane, maxdługość 50
        public string Title { get; set; }
        //TODO wymagane, maxdługość 200
        public string Description { get; set; }
    }
}
