#include "stdafx.h"

using namespace std;

A::A(int aX, int aY) : x(aX), y(aY)
{
    cout<<"A::A(int, int)"<<endl;
}

A::A(const A &a) : x(a.x), y(a.y)
{
    cout<<"A::A(const A&)"<<endl;
}

A::~A(void)
{
    cout<<"A::~A(void)"<<endl;
}

A & A::operator = (const A &aA)
{
    cout<<"A::operator = (const A&)"<<endl;

    if(this!=&aA)
    {
        x=aA.x*10;
        y=aA.y*10;
    }

    return(*this);
}

bool operator == (const A &aAL, const A &aAR)
{
   return(aAL.x==aAR.x && aAL.y==aAR.y);
}

bool operator != (const A &aAL, const A &aAR)
{
   return(!(aAL==aAR));
}
