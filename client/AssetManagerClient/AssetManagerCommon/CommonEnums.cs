using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagerCommon
{
    public class CommonEnums
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
        public enum STATUS
        {
            IN_USE=0,
            IN_STORAGE,
            LOANED_OUT,
            OUT_FOR_REPAIR,
        }
        public enum CONDITION
        {
            NEW=1,
            GOOD,
            FAIL,
            POOR,
        }
        public enum  FILTER
        {
            GROUP_TYPE=1,
            DEPARTMENT_USED,
            FILTER
        }
        public enum ACTION
        {
            ADD=1,
            EDIT,
            DELETE
        }
    }
}
