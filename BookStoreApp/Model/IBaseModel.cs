using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IBaseModel
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }

        int CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }

        int? ModifiedBy { get; set; }


    }
}
