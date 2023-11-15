ТЗ 

Редактор: 
- Unity 2021.3.23f1

Требования по верстке:
- ВАЖНО ОТКРЫТЬ МАКЕТ ПЕРЕД ПРОЧТЕНИЕМ -> PromoLayout (лежит в Assets\Project\Content\Layouts)
- Исходное разрешение канваса FullHD (портретное)
- Сверстать окно с ПРОМО элементами, которое состоит из трех секций содержащих промо элементы
- Каждая секция может скроллить\свайппать промки горизонтально (промо элементов может быть более 3х)
- У каждой секции есть заголовок
- Экран имеет общий вертикальный скролл\свайп
- У каждого элемента промо есть
	- Название
	- Цена
	- Рарность
	- Количество
	- Иконка
- Должна быть адаптивная верстка
- Сортировка промо элементов должна быть от Epic -> Common

Логика работы
- При старте появлятся LobbyView. реализовать обработку кнопки во вьюхе так, чтобы открывался экран ПРОМО.
- После открытия экрана ПРОМО, реализовать покупку промо. 
- Покупка промо. При клике на промо элемент, через UserService списывать кредиты и обновлять их в верхней части экрана ПРОМО
- Если кредитов не хватает, то выводить в консоль ошибку
- При клике на промо элемент менять его скейл (эмуляция нажати через скейл)
- Данные по промо элементам брать из PromoService.
- Открытие и закрытие экранов реализовать через UIService
- При успешной покупке выводить в консоль информацию о купленном промо (достаточно вывести название)
	

P.S
- В проекте есть все необходимы текстуры для верстки
- В качестве примера заведен пустой класс LobbyView с кнопкой (для экрана лобби), при клике на которую должно открываться окно ПРОМО
- Приолжен макет по которому нужно сверстать экран. файл называется: PromoLayout
- Начальная сцена Start
