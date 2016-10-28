using UnityEngine;
using System.Collections;

public interface DesktopElementInterface 
{

	string getElementName();
	void setElementName(string name);

	int getElementType();
	void setElementType(int type);


	void performOnClickAction();

}
