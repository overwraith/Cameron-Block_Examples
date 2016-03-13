/*Author: Cameron Block*/
using System;

namespace RecursivePrint
{
    public class ArgsException : Exception
    {
        private char errorArgumentId = '\0';
        private string errorParam = null;
        private ErrorCode errorCode = ErrorCode.OK;

        public ArgsException() { }

        public ArgsException(String message) : base(message) { }

        public ArgsException(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParam)
        {
            this.errorCode = errorCode;
            this.errorParam = errorParam;
        }

        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParam)
        {
            this.errorCode = errorCode;
            this.errorParam = errorParam;
            this.errorArgumentId = errorArgumentId;
        }

        public char getErrorArgumentId()
        {
            return errorArgumentId;
        }

        public void setErrorArgumentId(char errorArgumentId)
        {
            this.errorArgumentId = errorArgumentId;
        }

        public string getErrorParameter()
        {
            return this.errorParam;
        }

        public void setErrorParameter(string errorParam)
        {
            this.errorParam = errorParam;
        }

        public ErrorCode getErrorCode()
        {
            return this.errorCode;
        }

        public void setErrorCode(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public string errorMessage()
        {
            switch (errorCode)
            {
                case ErrorCode.OK:
                    return "TILT: Should not get here.";
                case ErrorCode.UNEXPECTED_ARGUMENT:
                    return string.Format("Argument {0} unexpected.", errorArgumentId);
                case ErrorCode.MISSING_STRING:
                    return string.Format("Could not find the string parameter for {0}.", errorArgumentId);
                case ErrorCode.INVALID_INTEGER:
                    return string.Format("Argument {0} expects an integer but was provided \"{1}\"", errorArgumentId, errorParam);
                case ErrorCode.MISSING_INTEGER:
                    return string.Format("Could not find integer parameter for {0}", errorArgumentId);
                case ErrorCode.INVALID_DOUBLE:
                    return string.Format("Argument {0} expects a double but was provided \"{1}\"", errorArgumentId, errorParam);
                case ErrorCode.MISSING_DOUBLE:
                    return string.Format("Could not find double parameter for {0}", errorArgumentId);
                case ErrorCode.INVALID_ARGUMENT_NAME:
                    return string.Format("\"{0}\" was not a valid argument name.", errorArgumentId);
                case ErrorCode.INVALID_ARGUMENT_FORMAT:
                    return string.Format("\"{0}\" is not a valid argument format.", errorParam);
            }
            return "";
        }//end method

    }//end class

    public enum ErrorCode
    {
        OK, INVALID_ARGUMENT_FORMAT, UNEXPECTED_ARGUMENT, INVALID_ARGUMENT_NAME,
        MISSING_STRING,
        MISSING_INTEGER, INVALID_INTEGER,
        MISSING_DOUBLE, INVALID_DOUBLE
    }

}//end namespace