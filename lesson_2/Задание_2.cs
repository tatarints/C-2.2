//задание 2
//метод бинарного поиска с использованием цикла
static int BinarySearch(int[] array, int searchedValue, int left, int right)
{
    //пока не сошлись границы массива
    while (left <= right)
    {
        //индекс среднего элемента
        var middle = (left + right) / 2;

        if (searchedValue == array[middle])
        {
            return middle;
        }
        else if (searchedValue < array[middle])
        {
            //сужаем рабочую зону массива с правой стороны
            right = middle - 1;
        }
        else
        {
            //сужаем рабочую зону массива с левой стороны
            left = middle + 1;
        }
    }
    //ничего не нашли
    return -1;
}
//асимптотическую сложность O(log n^2)