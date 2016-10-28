using UnityEngine;
using System.Collections;

public interface DesktopElementInterface 
{

	string getElementName();
	void setElementName(string name);

	int getElementType();
	void setElementType(int type);

	double getDesktopPositionX();
	void setDesktopPositionX(double posX);

	double getDesktopPositionY();
	void setDesktopPositionY(double posY);

	void performOnClickAction();

}
