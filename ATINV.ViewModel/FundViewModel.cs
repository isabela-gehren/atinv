﻿using System;

namespace ATINV.ViewModel
{
    public class FundViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public decimal MinInicialContribution { get; set; }
    }
}
