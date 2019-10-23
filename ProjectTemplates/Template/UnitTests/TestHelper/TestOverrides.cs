using System;
using $ext_safeprojectname$.Application.Contracts;

namespace $safeprojectname$.TestHelper
{
    internal class TestOverrides
    {
        public class DateProvider : IDateProvider
        {
            public DateTime Today { get; }

            public DateProvider(DateTime? date = null)
            {
                this.Today = date ?? new DateTime(2018, 09, 29);
            }
        }
    }
}
