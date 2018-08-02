import _winreg as winreg
import socket
import sys


def set_run_key(key, value):
    """
    Third action
     put program in the autorun of the computer

    :param key: Run Key Name
    :param value: Program to Run
    :return: None
    """
    # This is for the system run variable
    reg_key = winreg.OpenKey(
        winreg.HKEY_CURRENT_USER,
        r'Software\Microsoft\Windows\CurrentVersion\Run',
        0, winreg.KEY_SET_VALUE)

    with reg_key:
        if value is None:
            winreg.DeleteValue(reg_key, key)
        else:
            if '%' in value:
                var_type = winreg.REG_EXPAND_SZ
            else:
                var_type = winreg.REG_SZ
            winreg.SetValueEx(reg_key, key, 0, var_type, value)



def socket_example():
    """
    Second action
    example: a server of a TCP connection, i use it for a malware example
    """
    # Create a TCP/IP socket
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    # Bind the socket to the address given on the command line

    server_address = ('localhost', 11126)
    print >> sys.stderr, 'starting up on %s port %s' % server_address
    sock.bind(server_address)
    sock.listen(1)

    while True:
        print >> sys.stderr, 'waiting for a connection'
        connection, client_address = sock.accept()
        try:
            print >> sys.stderr, 'client connected:', client_address
            while True:
                data = connection.recv(16)
                print >> sys.stderr, 'received "%s"' % data
                if data:
                    connection.sendall(data)
                else:
                    break
        finally:
            connection.close()




def get_inro_forbidden_registry():
    reg_key = winreg.OpenKey( winreg.HKEY_USERS, r'S-1-5-19',
        0, winreg.KEY_SET_VALUE)

# first action, go into file in System32
f = open("C:\Windows\System32\AAA.txt", 'r')
print f.read()

#C:\Users\Laptop\Desktop\try1
#set_run_key("try5", 'C:\Users\Laptop\Desktop\\try1\\try2\New folder\\try5')
#get_inro_forbidden_registry()
socket_example()
print "hELLO@@#$%^&%$#"

