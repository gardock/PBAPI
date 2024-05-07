using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto.ObjectsDto
{
    public class ToDoListItemChangeOrderDto
    {
        public int Id { get; set; }
        [Range(1,255)]
        public byte NewOrder {  get; set; }
    }
}
