

using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;

public class DatabaseSettings
{


    string configPath;

    string _dbEngine;
    string _serverName;
    string _provider;
    string _databaseName;
    bool _trustedCon;
    bool _trustedCertification;
    public DatabaseSettings()
    {
        this.configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseSettings.xml");
        ReadXMLDocument();

    }

    private void ReadXMLDocument()
    {
        XmlTextReader xmlReader = new XmlTextReader(configPath);
         while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                if (xmlReader.AttributeCount > 0)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        if (xmlReader.Name == "DatabaseEngine")
                            _dbEngine = xmlReader.Value;

                        if (xmlReader.Name == "Server")
                            _serverName = xmlReader.Value;

                        if (xmlReader.Name == "Provider")
                            _provider = xmlReader.Value;

                        if (xmlReader.Name == "Database")
                            _databaseName = xmlReader.Value;

                        if (xmlReader.Name == "Trusted_Connection")
                            _trustedCon = Boolean.Parse(xmlReader.Value);

                        if (xmlReader.Name == "Trusted_Certification")
                            _trustedCertification = Boolean.Parse(xmlReader.Value);
                    }
                }
            }   
        }
    }


    public string Engine { get { return _dbEngine; } }
    public string Server { get { return _serverName; } }
    public string Provider { get { return _provider; } }
    public string Database {  get { return _databaseName; } }
    public bool TrustedConnection { get { return _trustedCon; } }
    public bool TrustedCertification { get { return _trustedCertification; } }


}