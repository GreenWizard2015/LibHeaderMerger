# LibHeaderMerger
Простенькая утилита на C# для слияния, по шаблону, заголовочных файлов С++ библиотек.

Очень уж люблю делить всё на отдельные файлы, но релизное публичное API удобнее получать в более компактном виде, объединяя несколько заголовочных файлов в один.

Пример использования в (pre-)build event:

`LHM.exe "$(ProjectDir)\PublicHeaders" "$(ProjectDir)\PublicAPI"`
