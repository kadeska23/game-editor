// GameGraph.h: interface for the GameGraph class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_GAMEGRAPH_H__E186FA8B_6424_48F5_8E99_B0ED8C7DF5AF__INCLUDED_)
#define AFX_GAMEGRAPH_H__E186FA8B_6424_48F5_8E99_B0ED8C7DF5AF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "GameControl.h"
#include "Action.h"
#include "Actor.h"
#include "engine/kyra.h"
#include "gedString.h"


void AddToGameGraph(Actor *to, int interation, Actor *from = NULL);
void GenerateGameGraph();
void ClearGameGraph();

//Avoid multiples graph add (like in execCreateActor action)
/*class AddInGameGraphControl
{
public:

	AddInGameGraphControl() 
	{
		n++;
	}

	virtual ~AddInGameGraphControl()
	{
		n--;

		if(n == 0 && to)
		{
			//Last call, can add to graph
			AddToGameGraph(to, interation);
			to = NULL;
		}
	}

	static void Add(Actor *_to, int _interation)
	{
		to = _to;
		interation = _interation;
	}

	static bool CanAdd() {return n == 0;}
	static void Reset() {n = 0;}

private:
	static Actor *to;
	static int interation;

	static int n;
};*/



#ifdef wxUSE_GUI

class stActorsName
{
public:
	stActorsName() {}
	stActorsName(char *name1, char *name2, int _interation) 
	{
		actorName1 = name1;
		actorName2 = name2;
		interation = _interation;
	}

	void operator=( const stActorsName& copy ) 
	{ 
		if( &copy != this )
		{
			actorName1 = copy.actorName1;
			actorName2 = copy.actorName2;
			interation = copy.interation;
		}
	}

	bool operator==( const stActorsName& copy ) 
	{ 
		//(A, B) != (B, A)
		if( actorName1 == copy.actorName1 && 
			actorName2 == copy.actorName2 && 
			interation == copy.interation )
		{
			return true;
		}

		return false;
	}

	gedString actorName1, actorName2;
	int interation;
};

class stActorsNameHash : public GlHash
{
  public:
	stActorsNameHash( const stActorsName& col )
	{	
		val = col.actorName1.getHash() + col.actorName2.getHash() + col.interation;
	}
};

typedef GlMap< stActorsName, int, stActorsNameHash >		MapActorsName;
typedef GlMapIterator< stActorsName, int, stActorsNameHash >		MapActorsNameIterator;

class wxBufferedPaintDC;

class GameGraph : public wxScrolledWindow  
{
	DECLARE_CLASS(GameGraph)
    DECLARE_EVENT_TABLE()

public:
	GameGraph(wxWindow *parent);
	virtual ~GameGraph();

	void AddActorInteration(char *actorName1, char *actorName2, int interation);
	void Clear();

	static GameGraph *Get();

	void GenerateGraph();

private:

	void DoPrepareDC(wxDC& dc);
	void OnPaint(wxPaintEvent &event);    
    void OnEraseBackground(wxEraseEvent &event);

	void Draw(wxBufferedPaintDC &dc);

	void OpenEngine(char *fileName);
	void CloseEngine();
	void GenerateGraphvizFile();
	void GenerateVCGFile();	

	MapActorsName mapActorInteration;
	int nSequence;
	int oldMaxX, oldMaxY;

	static GameGraph *gameGraph;	

	//Filters
	bool bShowSelfRelationship;
	bool bShowSequenceNumber;
	bool bShowEdgeLabels;
	gedString onlyRelationsWithActor;
};

#endif //#wxUSE_GUI

#endif // !defined(AFX_GAMEGRAPH_H__E186FA8B_6424_48F5_8E99_B0ED8C7DF5AF__INCLUDED_)
