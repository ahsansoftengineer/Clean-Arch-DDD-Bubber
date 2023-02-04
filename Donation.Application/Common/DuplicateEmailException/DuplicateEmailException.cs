using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Application.Common.DuplicateEmailException
{
  public class DuplicateEmailException : Exception
  {
    public DuplicateEmailException(string message):base(message) { }
  }
}
