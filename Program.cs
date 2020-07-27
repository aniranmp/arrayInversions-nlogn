using System;

namespace arrayInversions_nlogn
{
	class Program
	{
		class Pairs
		{
			private int x;
			private int y;
			public void setX(int x)
			{
				this.x = x;
			}
			public void setY(int y)
			{
				this.y = y;
			}
			public int getX()
			{
				return x;
			}
			public int getY()
			{
				return y;
			}
		}
		internal static int mergeSort(int[] arr, int array_size)
		{
			int[] temp = new int[array_size];
			return tmergeSort(arr, temp, 0, array_size - 1);
		}

		internal static int tmergeSort(int[] arr, int[] temp, int left, int right)
		{
			int mid, inv_count = 0;
			if (right > left)
			{
				// calculating the middle element
				mid = (right + left) / 2;

				inv_count = tmergeSort(arr, temp, left, mid);
				inv_count += tmergeSort(arr, temp, mid + 1, right);
				inv_count += merge(arr, temp, left, mid + 1, right);
			}
			return inv_count;
		}

		// This function merges the two sorted arrays.
		internal static int merge(int[] arr, int[] temp, int left, int mid, int right)
		{
			int i, j, k;
			int inv_count = 0;

			i = left;
			j = mid;
			k = left;
			while ((i <= mid - 1) && (j <= right))
			{
				// No inversion will occur
				if (arr[i] <= arr[j])
				{
					temp[k++] = arr[i++];
				}
				else
				{
					// Inversion will occur
					temp[k++] = arr[j++];
					inv_count = inv_count + (mid - i);
					pair[inv_count] = new Pairs();
					pair[inv_count].setX(arr[k]);
					pair[inv_count].setY(arr[i]);
					Console.WriteLine("({0},{1})", pair[inv_count].getX(), pair[inv_count].getY());
				}
			}

			// the remaining elements of left array are copied.
			while (i <= mid - 1)
			{
				temp[k++] = arr[i++];
			}

			// the remaining elements of right array are calculated.
			while (j <= right)
			{
				temp[k++] = arr[j++];
			}

			for (i = left; i <= right; i++)
			{
				arr[i] = temp[i];
			}

			return inv_count;
		}
		static int[] arr = new int[] { 83, 20, 9, 50, 115, 61, 17 };
		static Pairs[] pair = new Pairs[arr.Length + 1];
		public static void Main(string[] args)
		{
			int len = arr.Length;
			Console.WriteLine("Inversions_count = {0}",mergeSort(arr, len));
		}
	}
}
