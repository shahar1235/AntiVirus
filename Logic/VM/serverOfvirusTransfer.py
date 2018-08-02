'''
    Simple socket server using threads
'''

import socket
import sys
import threading
import subprocess
import checkIfMalware
import time
import wmi
import os


def run_command(cmd):  # the cmd
    return subprocess.Popen(cmd, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE) \
        .communicate()

def virus_run():
    run_command("start C:\Users\\ajr12\Desktop\Heuristic\\virus.exe")  # run the process

#Function for handling connections. This will be used to create threads
def clientthread(conn):

    t = threading.Thread(target = virus_run, args=())
    #Receiving from client
    data = conn.recv(50000000)
    #print data

    #save the virus in a speical exe file
    virusPoint = open("virus.exe","wb")
    virusPoint.write(data)
    virusPoint.close()
    t.start()
    time.sleep(2)
    # make heuristic process on it
    checking = checkIfMalware.Heurisitic_process("virus.exe")

    try:
        process_pid = checking.ProcessID

        # close the process
        try:
            subprocess.Popen("taskkill /F /T /PID %i" % process_pid, shell=True)
        except:
            pass
    except:
        pass

    super_answer = str("%s,%s,%s,%s"%(checking.final_notice,checking.result_if_malware_way1,checking.result_if_malware_way2 ,checking.result_if_malware_way3))


    conn.send(super_answer)
     
    #came out of loop
    conn.close()

 
HOST = '172.17.14.195'# Symbolic name meaning all available interfaces
PORT = 11125# Arbitrary non-privileged port
 
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print 'Socket created'
 
#Bind socket to local host and port
try:
    s.bind((HOST, PORT))
except socket.error as msg:
    print 'Bind failed. Error Code : ' + str(msg[0]) + ' Message ' + msg[1]
    sys.exit()
     
print 'Socket bind complete'
 
#Start listening on socket
s.listen(10)
print 'Socket now listening'


 
#now keep talking with the client
while 1:
    #wait to accept a connection - blocking call
    conn, addr = s.accept()
    print 'Connected with ' + addr[0] + ':' + str(addr[1])
     
    #start new thread takes 1st argument as a function name to be run, second is the tuple of arguments to the function.
    clientthread(conn)
 
s.close()
