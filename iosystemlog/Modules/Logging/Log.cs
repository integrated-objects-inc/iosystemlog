using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosystemlog.Modules.Logging
{
    public static class Log
    {
        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName)
        {
            Entry(systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName);
        }

        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage)
        {
            Entry(systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage);
        }

        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage)
        {
            Entry(systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage, exceptionMessage);
        }

        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage, string sql)
        {
            Entry(systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage, exceptionMessage, sql);
        }

        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage, string sql, string paramsIn)
        {
            Entry(systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage, exceptionMessage, sql, paramsIn);
        }

        public static void Entry(string connectionString, int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage, string sql, string paramsIn)
        {
            Entry(connectionString, systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage, exceptionMessage, sql, paramsIn, "");
        }

        public static void Entry(int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage, string sql, string paramsIn, string paramsOut)
        {
            Entry("", systemInstallKey, sysKey, appKey, userSesssionKey, errorCodeKey, returned, description, functionName, guiMessage, exceptionMessage, sql, paramsIn);
        }

        public static void Entry(string connectionString, int systemInstallKey, int sysKey, int appKey, int userSesssionKey, int errorCodeKey, bool returned, string description, string functionName, string guiMessage, string exceptionMessage, string sql, string paramsIn, string paramsOut)
        {
            var sqlCommand = new StringBuilder(@"INSERT INTO tSysLogs 
                                                     (SystemInstallKey, SysKey, AppKey, UserSessionKey, ErrorCodeKey, Returned, Description, FunctionName, GUIMessage, ExceptionMessage, SQL, ParamsIn, ParamsOut)
                                                 VALUES ([SYSTEMINSTALLKEY], [SYSKEY], [APPKEY], [USERSESSIONKEY], [ERRORCODEKEY], [RETURNED], [DESCRIPTION], [FUNCTIONNAME], [GUIMESSAGE], [EXCEPTIONMESSAGE], [SQL], [PARAMSIN], [PARAMSOUT])");

            sqlCommand.Replace("[SYSTEMINSTALLKEY]", EmptyToNull(systemInstallKey));
            sqlCommand.Replace("[SYSKEY]", EmptyToNull(sysKey));
            sqlCommand.Replace("[APPKEY]", EmptyToNull(appKey));
            sqlCommand.Replace("[USERSESSIONKEY]", EmptyToNull(userSesssionKey));
            sqlCommand.Replace("[ERRORCODEKEY]", EmptyToNull(errorCodeKey, false));
            sqlCommand.Replace("[RETURNED]", returned ? "1" : "0");
            sqlCommand.Replace("[DESCRIPTION]", EmptyToNull(description, 1024));
            sqlCommand.Replace("[FUNCTIONNAME]", EmptyToNull(functionName, 100));
            sqlCommand.Replace("[GUIMESSAGE]", EmptyToNull(guiMessage, 8000));
            sqlCommand.Replace("[EXCEPTIONMESSAGE]", EmptyToNull(exceptionMessage, 8000));
            sqlCommand.Replace("[SQL]", EmptyToNull(sql, 8000));
            sqlCommand.Replace("[PARAMSIN]", EmptyToNull(paramsIn, 8000));
            sqlCommand.Replace("[PARAMSOUT]", EmptyToNull(paramsOut, 8000));

            io.Data.Return<bool> insertResult;

            if (connectionString.Length != 0)
                insertResult = Databases.io_systemlog.Database.RunNonQuery(connectionString, sqlCommand.ToString(), false);
            else
                insertResult = Databases.io_systemlog.Database.RunNonQuery(sqlCommand.ToString());

            string message = insertResult.Message;
        }

        private static string EmptyToNull(int value)
        {
            return EmptyToNull(value, true);
        }

        private static string EmptyToNull(int value, bool zeroToNULL)
        {
            if (zeroToNULL && value == 0)
                return "NULL";
            else
                return value.ToString();
        }

        private static string EmptyToNull(string value, int maxLength)
        {
            if (value.Trim().Length > maxLength)
                value = value.Trim().Substring(0, maxLength);

            if (value.Trim().Length == 0)
                return "NULL";
            else
                return "'" + value.ToString().Replace("'","\"") + "'";
        }

    }
}
