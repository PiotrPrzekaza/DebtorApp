﻿using System;

namespace Debtor
{
    class Program
    {
        static void Main(string[] args)
        {
            var debtorApp = new DebtorApp();
            debtorApp.IntroductionDebtor();
            debtorApp.ChoiceYourAction();
        }
    }
}
