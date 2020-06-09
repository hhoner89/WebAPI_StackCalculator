using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_StackCalculator.Controllers
{
    [ApiController]

    public class StackController : ControllerBase
    {
        static Stack<decimal> stack = new Stack<decimal>();

        decimal numberOne;
        decimal numberTwo;

        decimal sum;
        decimal difference;
        decimal product;
        decimal quotient;

        [HttpGet]
        [Route("api/Test")]
        public string Test()
        {
            return "Success";
        }

        [HttpPost]
        [Route("api/Push")]
        public void Push([FromBody] decimal number)
        {
            if (stack.Count < 10)
            {
                stack.Push(number);
            }
        }

        [HttpPost]
        [Route("api/PushQuery")]
        public void PushQuery(decimal number)
        {
            stack.Push(number);
        }

        [HttpPost]
        [Route("api/Pop")]
        public void Pop()
        {
            stack.Pop();
        }

        [HttpPost]
        [Route("api/Print")]
        public decimal Print()
        {
            if(stack.Count == 0)
            {
                return 0;
            }
            else return stack.Peek();
        }

        [HttpPost]
        [Route("api/Add")]
        public decimal Add()
        {
            if (stack.Count >= 2)
            {
                numberOne = stack.Pop();
                numberTwo = stack.Pop();

                sum = numberOne + numberTwo;

                stack.Push(sum);                
            }
            return sum;
        }

        [HttpPost]
        [Route("api/Subtract")]
        public decimal Subtract()
        {
            if (stack.Count >= 2)
            {
                numberOne = stack.Pop();
                numberTwo = stack.Pop();

                difference = numberTwo - numberOne;

                stack.Push(difference);
            }
            return difference;
        }

        [HttpPost]
        [Route("api/Multiply")]
        public decimal Multiply()
        {
            if (stack.Count >= 2)
            {
                numberOne = stack.Pop();
                numberTwo = stack.Pop();

                product = numberOne * numberTwo;

                stack.Push(product);
            }
            return product;
        }

        [HttpPost]
        [Route("api/Divide")]
        public decimal Divide()
        {
            if (stack.Count >= 2)
            {
                numberOne = stack.Pop();
                numberTwo = stack.Pop();

                if (numberTwo != 0)
                {
                    quotient = numberTwo / numberOne;

                    stack.Push(quotient);
                }
            }
            return quotient;
        }
    }
}
