using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayPool<T>
{
	private readonly T[] array;
	private readonly int size;
	private int head;
	public int Count { get; private set; }

	private void HeadMoveRight()
	{
		head++;
		if (head >= size)
		{
			head -= size;
		}
		if (Count < size)
		{
			Count ++;
		}
	}

	private void HeadMoveLeft(int count = 1)
	{
		head -= count;
		Count -= count;
		if (head < 0)
		{
			head += size;
		}
		if (Count < 0)
		{
			Count = 0;
		}
	}

	public ArrayPool(int size)
	{
		this.size = size;
		array = new T[size];
		head = 0;
		Count = 0;
	}

	public void Add(T element)
	{
		HeadMoveRight();
		array[head] = element;
	}
	public ref T SetNext()
	{
		HeadMoveRight();
		return ref array[head];
	}

	public void Remove(int count = 1)
	{
		HeadMoveLeft(count);
	}
	
	public void Reset()
	{
		Count = 0;
		head = 0;
	}

	/// <param name="index"> 0 is current, 1 is previous</param>
	public ref T this[int index]
	{
		get
		{
			int i = head - index;
			if(i < 0)
			{
				i += Count;
			}

			return ref array[i];
		}
	}

}
