﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Easy.Extend;

namespace Easy.Web.CMS.Validate
{
    public class DefaultValidateService : IValidateService
    {
        const string ValidateCodeKey = "Session_ValidateCode";
        public byte[] GenerateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(5);
            HttpContext.Current.Session[ValidateCodeKey] = code;
            return validateCode.CreateValidateGraphic(code);
        }

        public bool ValidateCode(string code)
        {
            if (code.IsNullOrWhiteSpace()) return false;
            return code.Equals(HttpContext.Current.Session[ValidateCodeKey]);
        }
    }
}
