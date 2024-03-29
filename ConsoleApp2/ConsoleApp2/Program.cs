﻿int N = 5;          // задаем размер матрицы
int a[N][N];        // и инициализируем ее
for (int ik = 0; ik < N; ik++)
    for (int jk = 0; jk < N; jk++)
        a[ik][jk] = 0;          // заполнив для удобства нулями

for (int ik = 0; ik < N; ik++)
{     //назовем его "Основной цикл"
    for (int jk = 0; jk < N; jk++)
    {
        if (!(ik == 0 || ik == N - 1 || jk == 0 || jk == N - 1))
            continue;      // Временное условие для фильтрации элементов внесшего "кольца"
        int i = ik + 1;     // Номера строк и столбцов приводим в удобный
        int j = jk + 1;     // в математическом плане вид (от 1 до N)  
                            //  ... здесь будем вставлять основной код вычислений
    }
}

for (int ik = 0; ik < N; ik++)
{          //Блок "Вывод массива"
    for (int jk = 0; jk < N; jk++)
    {
        printf("%02d ", a[ik][jk]); // дополняем число ведущими нулями
    }
    cout << endl;
}
return 0;