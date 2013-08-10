using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagerCommon
{
    public class CommonFunction
    {
        public static string GetMassageReturn(int retcode)
        {
            switch (retcode)
            {
                case (int)CommonEnums.RetCode.SUCCESS:
                    return "Thành công";
                case (int)(int)CommonEnums.RetCode.SYSTEM_ERROR:
                    return "Lỗi hệ thống";
                case (int)CommonEnums.RetCode.DATA_ALREADY_EXIST:
                    return "Dữ liệu đã tồn tại";
                case (int)CommonEnums.RetCode.NOT_PERMISSION:
                    return "Không có quyền thực hiện tác vụ này";
                case (int)CommonEnums.RetCode.OTHER:
                    return "Lỗi khác";
                case (int)CommonEnums.RetCode.NOT_ALLOW:
                    return "Không được phép thực hiện thao tác này";
                case (int)CommonEnums.RetCode.INCORRECT_USERNAME_PASSWORD:
                    return "Không đúng tên đăng nhập hoặc mật khẩu";
                case (int)CommonEnums.RetCode.FAIL:
                    return "Lỗi";
                case (int)CommonEnums.RetCode.DATA_CONFLICT:
                    return "Dữ liệu mâu thuẫn";
            }
            return "";
        }
    }
}
