Проект содержит API и 3 сервиса, которые имитируют работу. GUI для работы с API это Swagger UI, на GET запрос API ответит информацией о всех сервисах. Сервисы стартуют при запуске приложения, информация об их состоянии сохраняется через определенные промежутки времени (чтобы не обновлять БД каждые 2 секунды). Поэтому следует сделать GET запрос только после первого обновления БД (после фразы "База данных обновлена" в консоли).
