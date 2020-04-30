﻿using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MAVN.Service.PartnerApi.Infrastructure.CustomAttributes
{
    public class RequiredListAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return (value as IEnumerable)?.GetEnumerator().MoveNext() ?? false;
        }
    }
}

