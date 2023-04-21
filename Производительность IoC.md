# Производительность IoC

Сравниваем 3 контейнера:

* [**Autofac**](https://github.com/autofac/Autofac)  - 7.0.1 
* [**DryIoC**](https://github.com/dadhi/DryIoc)  -  5.3.4
* [**Microsoft.DependencyInjections**](https://github.com/dadhi/DryIoc) - 7.0.0

## Конфигурация запуска 

*Runtime* запуска тестов - .Net6

Бенчмарки выполняются на следующей конфигурации машины

* *CPU*: Intel(R) Core(TM) i9-12900F   2.40 GHz

* *Memory*: 32 GB

## Список бенчмарков

Код бенчмарков взят [отсюда](https://github.com/danielpalme/IocPerformance).

- Singleton: Создание синглетон-объекта Objects with is singleton lifetime are resolved
- Transient: Создание объекта по запросу Objects with is transient lifetime are resolved
- Combined: Создание синглетона и по запросу
- Complex: Создание сложного объекта со вложенностями
- Property: Инжекция зависимости через свойство
- Generics: Создание Generic-класса
- IEnumerable: Создание множества объектов, реализующих один интерфейс
- Conditional: Создание объекта по условию
- Child Container: Создание объекта через дочерний контейнер
- ASP NET Core: Создание объектов при интеграции его в ASP NET Core приложении
- Prepare And Register: Инициализация и регистрация контейнера (3000 раз)
- Prepare And Register And Simple Resolve: Инициализация и регистрация контейнера. Плюс создание двух объектов ( 3000 раз) 

Каждый тест запускается однопоточно и многопоточно. 

## Результаты

### Базовые возможности
| **Container**                                                |     **Singleton** |     **Transient** |      **Combined** |       **Complex** |
| :----------------------------------------------------------- | ----------------: | ----------------: | ----------------: | ----------------: |
| **[Autofac 7.0.1](https://github.com/autofac/Autofac)**      |       359<br/>167 |       373<br/>200 |       916<br/>488 |     2771<br/>1404 |
| **[DryIoc 5.3.4](https://github.com/dadhi/DryIoc)**          | **34**<br/>**29** | **43**<br/>**42** | **53**<br/>**53** |     75<br/>**58** |
| **[Microsoft Extensions DependencyInjection 7.0.0](https://github.com/aspnet/Extensions)** |     **34**<br/>37 |         45<br/>55 |         55<br/>64 | **73**<br/>**58** |

### Дополнительные возможности
| **Container**                                                |       **Property** |      **Generics** |    **IEnumerable** |   **Conditional** |    **Child Container** |    **Asp Net Core** |
| :----------------------------------------------------------- | -----------------: | ----------------: | -----------------: | ----------------: | ---------------------: | ------------------: |
| **[Autofac 7.0.1](https://github.com/autofac/Autofac)**      |      2844<br/>1489 |       749<br/>396 |      2824<br/>2321 |      1159<br/>700 | **35443**<br/>**9236** |      13735<br/>7124 |
| **[DryIoc 5.3.4](https://github.com/dadhi/DryIoc)**          | **111**<br/>**76** | **50**<br/>**42** | **155**<br/>**96** | **53**<br/>**44** |                  <br/> | **751**<br/>**465** |
| **[Microsoft Extensions DependencyInjection 7.0.0](https://github.com/aspnet/Extensions)** |              <br/> |         53<br/>45 |        162<br/>101 |             <br/> |                  <br/> |        1116<br/>632 |

### Подготовка контейнера
| **Container**                                                | **Prepare And Register** | **Prepare And Register And Simple Resolve** |
| :----------------------------------------------------------- | -----------------------: | ------------------------------------------: |
| **[Autofac 7.0.1](https://github.com/autofac/Autofac)**      |                  98<br/> |                                    109<br/> |
| **[DryIoc 5.3.4](https://github.com/dadhi/DryIoc)**          |                  13<br/> |                                     14<br/> |
| **[Microsoft Extensions DependencyInjection 7.0.0](https://github.com/aspnet/Extensions)** |               **8**<br/> |                                 **11**<br/> |

### Графики

![Singleton](./img/Singleton.png)

![Transient](./img/Transient.png)

![Combined](./img/Combined.png)

![Complex](./img/Complex.png)

![Property](./img/Property.png)

![Generics](./img/Generics.png)

![IEnumarable](./img/IEnumerable.png)

![Conditional](./img/Conditional.png)

![Child](./img/Child%20Container.png)

![ASP NET Core](./img/Asp%20Net%20Core.png)

![Prepare and Register](./img/Prepare%20And%20Register.png)

![Prepare And Register and Simple Resolve](./img/Prepare%20And%20Register%20And%20Simple%20Resolve.png)