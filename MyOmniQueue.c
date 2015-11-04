/*Author: Cameron Block*/
#include <stdio.h>
#include <stdlib.h>

struct OmniNode{
void *dataPtr;
struct OmniNode *nextPtr;
};

typedef struct OmniNode *QueueNodePtr;

int isempty(QueueNodePtr headPtr);//Development Order: 1
void enqueue(QueueNodePtr *headPtr, QueueNodePtr *tailPtr);//Development Order: 2
void printQueue(QueueNodePtr currentPtr, char fmtStr[]);//Development Order: 3
void *dequeue(QueueNodePtr *headPtr, QueueNodePtr *tailPtr);//Development Order: 4

int main(void)
{
	QueueNodePtr headPtr=NULL;
	QueueNodePtr tailPtr=NULL;
	char myChar='a';
	char value;

	//if(isempty(headPtr))//testing if isempty function works
		//printf("The Queue is Empty. \n");

	enqueue(&headPtr, &tailPtr, (void *)myChar);
	printQueue(headPtr, "%c --> ");
	value=(char)dequeue(&headPtr, &tailPtr);
	printQueue(headPtr, "%c --> ");

	printf("The Returned Value is: %c\n", value);

	system("pause");
}

int isempty(QueueNodePtr headPtr)//Development Order: 1
{
	return headPtr==NULL;
}

void enqueue(QueueNodePtr *headPtr, QueueNodePtr *tailPtr, void *valuePtr)//Development Order: 2
{
	//pointer to new node
	QueueNodePtr newPtr;

	//allocate space for new node
	newPtr=(QueueNodePtr)malloc(sizeof(struct OmniNode));

	if(newPtr != NULL)
	{
		newPtr->dataPtr=valuePtr;
		newPtr->nextPtr=NULL;
		//printf("The Character is: %c\n", valuePtr);

		if(isempty(*headPtr))
			*headPtr=newPtr;
		else
			(*tailPtr)->nextPtr=newPtr;
		
		(*tailPtr)=newPtr;
	}
	else
		exit(1);//exit with a fail state, no memory was allocated
}

void printQueue(QueueNodePtr currentPtr, char fmtStr[])//Development Order: 3
{
	if(currentPtr==NULL)
		printf("Queue is empty. \n\n");
	else
	{
		printf("The Queue is: \n");
		while(currentPtr != NULL)
		{
			printf(fmtStr, currentPtr->dataPtr);
			currentPtr=currentPtr->nextPtr;
		}
		printf("NULL \n\n");
	}
}

void *dequeue(QueueNodePtr *headPtr, QueueNodePtr *tailPtr)//Development Order: 4
{//these functions look like they are using double pointers, should do something to remove it a level of indirection
	void *value;
	QueueNodePtr tempPtr;

	value=(*headPtr)->dataPtr;
	tempPtr=*headPtr;
	*headPtr=(*headPtr)->nextPtr;

	if(*headPtr==NULL)
		*tailPtr=NULL;

	free(tempPtr);
	return value;
}