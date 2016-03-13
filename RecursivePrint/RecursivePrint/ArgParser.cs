/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursivePrint
{
    public class ArgParser
    {
        private Dictionary<char, ArgStrategy> strategies;
        private HashSet<char> argsFound;
        private IEnumerator<string> currentArg;

        public ArgParser(string schema, string[] args)
        {
            strategies = new Dictionary<char, ArgStrategy>();
            argsFound = new HashSet<char>();

            parseSchema(schema);
            parseArgumentStrings(args.ToList());
        }

        public void parseSchema(string schema)
        {
            foreach (string element in schema.Split(','))
                if (element.Length > 0)
                    parseSchemaElement(element.Trim());
        }

        public void parseSchemaElement(string element)
        {
            char elementId = element[0];
            string elementTail = element.Substring(1);

            validateSchemaElementId(elementId);

            if (elementTail.Length == 0)
                strategies.Add(elementId, new BooleanArgStrategy());
            else if (elementTail.Equals("*"))
                strategies.Add(elementId, new StringArgStrategy());
            else if (elementTail.Equals("#"))
                strategies.Add(elementId, new IntegerArgStrategy());
            else if (elementTail.Equals("##"))
                strategies.Add(elementId, new DoubleArgStrategy());
            else if (elementTail.Equals("[*]"))
                strategies.Add(elementId, new StringArrayArgStrategy());
            else
                throw new ArgsException();
        }

        private void validateSchemaElementId(char elementId)
        {
            if (!char.IsLetter(elementId))
                throw new ArgsException(ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
        }

        private void parseArgumentStrings(List<string> argsList)
        {
            this.currentArg = argsList.GetEnumerator();
            IEnumerator<string> previousArg = argsList.GetEnumerator();

            while (currentArg.MoveNext())
            {
                var ctStr = currentArg.Current;

                if (ctStr.StartsWith("-"))
                    parseArgumentCharacters(ctStr.Substring(1));
                else {
                    currentArg = previousArg;//equivalent of java's iterator previous() method
                    break;
                }

                previousArg.MoveNext();
            }//end loop

        }//end method

        private void parseArgumentCharacters(string argChars)
        {
            for (int i = 0; i < argChars.Length; i++)
                parseArgumentCharacter(argChars[i]);
        }

        private void parseArgumentCharacter(char argChar)
        {
            ArgStrategy strategy = strategies[argChar];//get the right strategy

            if (strategy == null)
                throw new ArgsException(ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
            else {
                argsFound.Add(argChar);
                try
                {
                    strategy.set(currentArg);
                }
                catch (ArgsException e)
                {
                    e.setErrorArgumentId(argChar);
                    throw e;
                }
            }//end else

        }//end method

        public bool hasFlag(char arg)
        {
            return argsFound.Contains(arg);
        }

        public void nextArgument()
        {
            currentArg.MoveNext();
        }

        public bool getBoolean(char arg)
        {
            return BooleanArgStrategy.getValue(strategies[arg]);
        }

        public string getString(char arg)
        {
            return StringArgStrategy.getValue(strategies[arg]);
        }

        public int getInt(char arg)
        {
            return IntegerArgStrategy.getValue(strategies[arg]);
        }

        public double getDouble(char arg)
        {
            return DoubleArgStrategy.getValue(strategies[arg]);
        }

        public string[] getStringArray(char arg)
        {
            return StringArrayArgStrategy.getValue(strategies[arg]);
        }

    }//end class

    public interface ArgStrategy
    {
        void set(IEnumerator<string> currentArg);
    }

    public class BooleanArgStrategy : ArgStrategy
    {
        private bool Value = false;
        public void set(IEnumerator<string> currentArg)
        {
            this.Value = true;
        }

        public static bool getValue(ArgStrategy strategy)
        {
            if (strategy != null && strategy is BooleanArgStrategy)
                return ((BooleanArgStrategy)strategy).Value;
            else
                return false;
        }
    }//end class

    public class StringArgStrategy : ArgStrategy
    {
        private string Value = null;
        public void set(IEnumerator<string> currentArg)
        {

            if (!currentArg.MoveNext())
                throw new ArgsException(ErrorCode.MISSING_STRING);

            Value = currentArg.Current;
        }//end method

        public static string getValue(ArgStrategy strategy)
        {
            if (strategy != null && strategy is StringArgStrategy)
                return ((StringArgStrategy)strategy).Value;
            else
                return "";
        }
    }//end class

    public class IntegerArgStrategy : ArgStrategy
    {
        private int Value = 0;
        public void set(IEnumerator<string> currentArg)
        {

            if (!currentArg.MoveNext())
                throw new ArgsException(ErrorCode.MISSING_INTEGER);

            try
            {
                Value = int.Parse(currentArg.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.INVALID_INTEGER, currentArg.Current);
            }
        }//end method

        public static int getValue(ArgStrategy strategy)
        {
            if (strategy != null && strategy is IntegerArgStrategy)
                return ((IntegerArgStrategy)strategy).Value;
            else
                return 0;
        }
    }//end class

    public class DoubleArgStrategy : ArgStrategy
    {
        private double Value = 0;
        public void set(IEnumerator<string> currentArg)
        {

            if (!currentArg.MoveNext())
                throw new ArgsException(ErrorCode.MISSING_DOUBLE);

            try
            {
                Value = double.Parse(currentArg.Current);
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.INVALID_DOUBLE, currentArg.Current);
            }
        }//end method

        public static double getValue(ArgStrategy strategy)
        {
            if (strategy != null && strategy is DoubleArgStrategy)
                return ((DoubleArgStrategy)strategy).Value;
            else
                return 0;
        }
    }//end class

    public class StringArrayArgStrategy : ArgStrategy
    {
        private String[] Value = null;
        public void set(IEnumerator<string> currentArg)
        {

            if (!currentArg.MoveNext())
                throw new ArgsException(ErrorCode.MISSING_DOUBLE);

            try
            {
                Value = currentArg.Current.Split(',');
            }
            catch (FormatException)
            {
                throw new ArgsException(ErrorCode.INVALID_DOUBLE, currentArg.Current);
            }
        }//end method

        public static string[] getValue(ArgStrategy strategy)
        {
            if (strategy != null && strategy is StringArrayArgStrategy)
                return ((StringArrayArgStrategy)strategy).Value;
            else
                return null;
        }
    }//end class

}//end namespace
