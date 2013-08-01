using System;
using Ventuz.Kernel;
using System.Xml;


public class Script : ScriptBase, System.IDisposable
{
    
  // This member  used by the Validate() method to indicate
	// whether the Generate() method should return true or false
	// during its next execution.
	private bool changed;
	string[] _loadedText;
	// This Method is called if the component is loaded/created.
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
		doc.LoadXml("<inputs></inputs>");
		
		//element1
		foreach (string s in textToSave)
		{
		XmlElement Text = doc.CreateElement("text");
		Text.InnerText = Convert.ToString(s);

		
		doc.DocumentElement.AppendChild(Text);
		

		}
		doc.Save("C:\\Users\\basti\\Desktop\\data.xml");		
		return false;
		}
	
	// This Method is called if the function/method load is invoked by the user or a bound event.
	// Return true, if this component has to be revalidated!
	public bool Onload(int arg)
	{
		
		
			
		XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
		xmlDoc.Load("C:\\Users\\basti\\Desktop\\data.xml"); //* load the XML document from the specified file.

		//* Get elements.
		XmlNodeList Text = xmlDoc.GetElementsByTagName("text"); ;
		_loadedText = new string[Text.Count];
		//* Display the results.
		
		int i = 0;
		foreach (XmlNode s in Text)
		{
			
			_loadedText[i] = s.InnerText;
			// _loadedText = new string[]{ "sjdfhjsdhfkjsdhf", "asdgasdg" };
			i++;
			
		}

		
		
		changed = true;
		return false;
	}


}
