﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagerCommon
{
    class CommonEnums
    {
        public enum RetCode
        {
            SUCCESS = 0,
            FAIL,
            NOT_LOGIN,
            INCORRECT_DATE_FORMAT,
            INCORRECT_TIME_FORMAT,
            PASSWORD_LENGTH_INCORRECT,
            OLD_PASSWORD_INCORRECT,
            PASSWORD_NOT_MATCH,
            USER_INACTIVED,
            INCORRECT_USERNAME_PASSWORD,
            NO_EXIST_DATA,
            DATA_ALREADY_EXIST,
            DATA_CONFLICT,
            INCORRECT_DATA,
            MUST_FUTURE_DATE,
            NO_MEDICAL_CLINIC,
            MUST_HAVE_REJECT_REASON,
            NOT_ALLOW,
            NOT_PERMISSION,
            ERROR_SENDING_SMS,
            OTHER = 99,
            SYSTEM_ERROR = 100,
        }
    }
}
