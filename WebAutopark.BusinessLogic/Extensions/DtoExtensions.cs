using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class DtoExtensions
    {
        public static OrderPartDto DoAction(this OrderPartDto dto, Action<OrderPartDto> action)
        {
            action(dto);
            return dto;
        }
    }
}
