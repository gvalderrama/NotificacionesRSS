#region Using

using System;
using System.Xml;
using System.Collections.ObjectModel;
using PC;
#endregion



[Serializable]
public class RssManager : IDisposable
{
    #region Variables
    private string _url;
    private string _feedTitle;
    private string _feedDescription;
    private Collection<Rss.Items> _rssItems = new Collection<Rss.Items>();
    private bool _IsDisposed;
    #endregion

    #region Constructors
    /// <summary>
    /// Empty constructor, allowing us to
    /// instantiate our class and set our
    /// _url variable to an empty string
    /// </summary>
    public RssManager()
    {
        _url = string.Empty;
    }

    /// <summary>
    /// Constructor allowing us to instantiate our class
    /// and set the _url variable to a value
    /// </summary>
    /// <param name="feedUrl">The URL of the Rss feed</param>
  public RssManager(string feedUrl)
  {
    _url = feedUrl;
  }

  #endregion

  #region Properties  
  /// <summary>
  /// Gets or sets the URL of the RSS feed to parse.
  /// </summary>
  public string Url
  {
    get { return _url; }
    set { _url = value; }
  }

  
  /// <summary>
  /// Gets all the items in the RSS feed.
  /// </summary>
  public Collection<Rss.Items> RssItems
  {
    get { return _rssItems; }
  }
      
  /// <summary>
  /// Gets the title of the RSS feed.
  /// </summary>
  public string FeedTitle
  {
    get { return _feedTitle; }
  }
      
  /// <summary>
  /// Gets the description of the RSS feed.
  /// </summary>
  public string FeedDescription
  {
    get { return _feedDescription; }
  }

  #endregion

  #region Methods

  

  /// <summary>
  /// Retrieves the remote RSS feed and parses it.
  /// </summary>
  public Collection<Rss.Items> GetFeed()
  {
		//Verificamos que la rss no este vacia
    if (String.IsNullOrEmpty(Url))

			//Prueba link noticias de terra.cl
			//falta mudificar PainWindows para que muestre la pagina
			throw new ArgumentException("http://noticias.terra.cl/rss/Controller?channelid=8401b9c4f94b1310VgnVCM10000098f154d0RCRD&ctName=atomo-noticia&lg=es-cl");

		//iniciamos el proceso de analisis
    using (XmlReader reader = XmlReader.Create(Url))
    {
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load(reader);
      //parse the items of the feed
      ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "title", ref _feedTitle);
      ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "description", ref _feedDescription);
      ParseRssItems(xmlDoc);
      //return the feed items
      return _rssItems;
    }
  }

  /// <summary>
  /// Parses the xml document in order to retrieve the RSS items.
  /// </summary>
  private void ParseRssItems(XmlDocument xmlDoc)
  {
    _rssItems.Clear();
    XmlNodeList nodes = xmlDoc.SelectNodes("rss/channel/item");

    foreach (XmlNode node in nodes)
    {
      Rss.Items item = new Rss.Items();
      ParseDocElements(node, "title", ref item.Title);
      ParseDocElements(node, "description", ref item.Description);
      ParseDocElements(node, "link", ref item.Link);

      string date = null;
      ParseDocElements(node, "pubDate", ref date);
      DateTime.TryParse(date, out item.Date);

      _rssItems.Add(item);
    }
  }

  /// <summary>
  /// Parses the XmlNode with the specified XPath query 
  /// and assigns the value to the property parameter.
  /// </summary>
  private void ParseDocElements(XmlNode parent, string xPath, ref string property)
  {
    XmlNode node = parent.SelectSingleNode(xPath);
    if (node != null)
      property = node.InnerText;
    else
      property = "Unresolvable";
  }

  #endregion

  #region IDisposable Members  

  /// <summary>
  /// Performs the disposal.
  /// </summary>
  private void Dispose(bool disposing)
  {
    if (disposing && !_IsDisposed)
    {
      _rssItems.Clear();
      _url = null;
      _feedTitle = null;
      _feedDescription = null;
    }

    _IsDisposed = true;
  }

  /// <summary>
  /// Releases the object to the garbage collector
  /// </summary>
  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  #endregion

}