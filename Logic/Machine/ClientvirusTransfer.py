import socket
import sys
import hashlib




class checkForNewDownLoad:

    suspicionVirus_name = None
    def __init__(self, suspicionVirus_name):
        self.suspicionVirus_name = suspicionVirus_name
        self.total_answer = self.check_by_signature()


    def check_by_heuristic(self,virus_data):
        # Create a TCP/IP socket
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        # Connect the socket to the port where the server is listening
        server_address = ('172.17.14.195', 11125)
        print >>sys.stderr, 'connecting to %s port %s' % server_address
        sock.connect(server_address)


        # Send data

        sock.send(virus_data)

        data = sock.recv(30)
        self.arr_answers = data.split(',')
        print >> sys.stderr, 'received "%s"' % data
        print >> sys.stderr, 'closing socket'
        sock.close()
        if self.arr_answers[0] == "True":
            blocksize = 65536
            # create the hash-MD5 hash
            hasher = hashlib.md5()
            with open(self.suspicionVirus_name, 'rb') as afile:
                buf = afile.read(blocksize)
                while len(buf) > 0:
                    hasher.update(buf)
                    buf = afile.read(blocksize)

            # update the new virus signature in the DB
            f = open("C:\Signature_DB.txt", 'a')
            f.writelines(["\n%s" % hasher.hexdigest()])
            f.close()
            return True
        else:
            return False




    def check_by_signature(self):
        with open("C:\Signature_DB.txt", 'rb') as signature_file:
            signatures = signature_file.read()
            signatures = signatures.splitlines()
        # get the signature
        blocksize = 1000000
        # create the hash-MD5 hash
        hasher = hashlib.md5()

        # take the data from the virus
        with open(self.suspicionVirus_name, 'rb') as afile:
            buf = afile.read()
            # create a copy because one id for the signature and one is for the heuristic
            virus_data = str(buf)
            while len(buf) > 0:
                hasher.update(buf)
                buf = afile.read(blocksize)

        signature_file = hasher.hexdigest()
        for i in signatures:
            if i == signature_file:
                return True

        return self.check_by_heuristic(virus_data)



