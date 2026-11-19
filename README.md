# InterProcessCommunication

Solution на WinForms (.NET 10, Windows): отправитель передаёт текст получателю, и тот ставит его в заголовок своего окна.

Каждый способ IPC — отдельная пара проектов `*.Sender` / `*.Receiver`. Сначала запускайте получателя, затем отправителя.

| Проекты | Как передаётся текст |
| --- | --- |
| `FileIpc.Sender` / `FileIpc.Receiver` | общий файл `%TEMP%\ipc-lab-title.txt`; получатель опрашивает его таймером |
| `WinApiIpc.Sender` / `WinApiIpc.Receiver` | `FindWindow` по скрытому маркеру и `SetWindowText` у главного окна |
| `TcpIpc.Sender` / `TcpIpc.Receiver` | TCP: получатель слушает порт **5050**, отправитель шлёт одну UTF-8 строку |
| `ComIpc.Sender` / `ComIpc.Receiver` | COM-объект `ITitleController` в Running Object Table (`ComIpc.Contracts`) |

Открытие: `InterProcessCommunication.slnx`.
