using System.Collections.Generic;

namespace Common.Modules.Base
{
    public class Parameters
    {
        #region core
        private readonly IDictionary<string, string> _parameters;
        #endregion

        #region init
        public Parameters(IDictionary<string, string> parameters)
        {
            _parameters = new Dictionary<string, string>(parameters);
        }
        #endregion

        #region public methods
        public string this[string key]
        {
            get
            {
                return _parameters.ContainsKey(key) ? _parameters[key] : null;
            }
        }
        #endregion
    }
}
