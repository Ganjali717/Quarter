﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
    }
}
