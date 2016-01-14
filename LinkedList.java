package test;

class LinkedListNode
{
	int value;
	LinkedListNode next;
	LinkedListNode(int v)
	{
		this.value = v;
	}
}
public class LinkedList {
	public LinkedListNode head;
	LinkedList()
	{
		head = null;
	}
	
	void addAtBeginning(int v)
	{
		LinkedListNode newNode = new LinkedListNode(v);
		if(head == null) head = newNode;
		else
		{
			newNode.next = head;
			head = newNode;
		}
	}
	
	void printList()
	{
		LinkedListNode temp = head;
		while(temp != null)
		{
			System.out.print(temp.value + " ");
			temp = temp.next;
		}
	}
	
	void revertInPlace()
	{
		LinkedListNode prev;
		LinkedListNode current;
		LinkedListNode next;
		
		if(head == null || head.next == null)
			return;
		prev = null;
		current = head;
		next =  current.next;		
		while(current.next != null)
		{
			current.next = prev;
			prev = current;
			current = next;
			next = current.next;
		}
		current.next = prev;
		head = current;
		
	}
	
	void revereInPlaceVersion2()
	{
		if(head == null || head.next == null)
			return;
		LinkedListNode current = head;
		LinkedListNode prev = null;
		LinkedListNode next = null;
		while(current != null)
		{
			next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		head = prev;
		
	}
	
	public static void main(String[] args)
	{
		LinkedList l = new LinkedList();
		l.addAtBeginning(4);
		l.addAtBeginning(3);
		l.addAtBeginning(2);
		l.addAtBeginning(1);
		l.printList();
		System.out.println();
		l.revertInPlace();
		l.printList();
		System.out.println();
		l.revereInPlaceVersion2();
		l.printList();
	}
	
	
    


}
