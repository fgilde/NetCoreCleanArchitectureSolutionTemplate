using System;
using $ext_safeprojectname$.Application.Contracts;

namespace $safeprojectname$
{
    internal class DateProvider : IDateProvider
    {
        public DateTime Today => DateTime.Today;
    }
}