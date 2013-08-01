using System;
using Ventuz.Kernel;
using System.Xml;


public class Script : ScriptBase, System.IDisposable
{
    
  	// This member  used by the Validate() method to indicate
	// whether the Generate() method should return true or false
	// during its next execution.
	private bool changed;
	//create a temporary array
	// See here why temporary arrays are needed: http://sebastianspiegl.de/?q=Working-with-matrices-and-arrays-in-Ventuz-C%23-scripts%20
	string[] _loadedText;
	// This method is called if the component is loaded/created.
	public Script()
	{


		// Note: Accessing input or output properties from this method
		// will have no effect as they have not been allocated yet.
	}
    
	// This Method is called if the component is unloaded/disposed
	public virtual void Dispose()
	{
	}
    
	// This Method is called if an input property has changed its value
	public override void Validate()
	{
		// Remember: set changed to true if any of the output 
		// properties has been changed, see Generate()


	}
    
	// This Method is called every time before a frame is rendered.
	// Return value: if true, Ventuz will notify all nodes bound to this
	//               script node that one of the script's outputs has a
	//               new value and they therefore need to validate. For
	//               performance reasons, only return true if output
	//               values really have been changed.
	public override bool Generate()
	{

		// assaign temp array to the output array.
		// See here why temporary arrays are needed: http://sebastianspiegl.de/?q=Working-with-matrices-and-arrays-in-Ventuz-C%23-scripts%20
		loadedText = _loadedText;



		changed = true;

		if (changed)
		{
			changed = false;
			return true;
		}

		return false;
	}

	// This Method is called if the function/method save is invoked by the user or a bound event.
	// Return true, if this component has to be revalidated!
	public bool Onsave(int arg)
	{

		XmlDocument doc = new XmlDocument();
		//create the basic structure of the XML
		doc.LoadXml("<inputs></inputs>");

		//get each element in the array that needs to be saved
		foreach (string s in textToSave)
		{

			//create a text node per array element
			XmlElement Text = doc.CreateElement("text");
			//fill it with array element data 
			Text.InnerText = Convert.ToString(s);
			//append node to the XML base document
			doc.DocumentElement.AppendChild(Text);


		}
		//save document
		doc.Save(fileName);

		return false;
		}

	// This Method is called if the function/method load is invoked by the user or a bound event.
	// Return true, if this component has to be revalidated!
	public bool Onload(int arg)
	{



		XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
		//load XML document
		xmlDoc.Load(fileName); //* load the XML document from the specified file.

		//Get all nodes with thw name "text".
		XmlNodeList Text = xmlDoc.GetElementsByTagName("text");
		//create a temp array the size of nodes count
		_loadedText = new string[Text.Count];


		//create an indexer
		int i = 0;

		//get each node in the nodeList
		foreach (XmlNode s in Text)
		{
			//assign each node content to the temp array at position i
			_loadedText[i] = s.InnerText;
			//increment indexer i
			i++;

		}



		changed = true;
		return false;
	}


}
