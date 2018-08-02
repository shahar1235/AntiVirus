import os
import hashlib

import time


class searchSignature:

    def __init__(self, path):
        self.suspicions_files = []
        self.scan(path)

    def scan(self, path):
        """
        pass after a directory and check if the is a malware there by scanning signatures of the files
        :return: a list of the pathes of all the suspicions files
        """

        self.suspicions_files = []
        num_of_suspicions_files = 0
        num_of_scannings_files = 0

        for root, dirs, files in os.walk(r"%s" % path):
            for i in range(len(files)):
                path_of_the_file = str(root + '\\' + files[i])
                try:
                    with open("%s" % path_of_the_file, 'rb') as CheckingFile:
                        filedata = CheckingFile.read()
                        if filedata != "":
                            hasher = hashlib.md5()
                            hasher.update(filedata)
                            fileSignature = hasher.hexdigest()

                            with open("C:\Signature_DB.txt", 'rb') as signature_file:
                                signatures = (signature_file.read()).splitlines()
                                num_of_scannings_files += 1
                                if signatures:
                                    for j in range(len(signatures)):
                                        if signatures[j] == fileSignature:
                                            self.suspicions_files.append(path_of_the_file)
                                            num_of_suspicions_files += 1
                                            break
                except:
                    pass

        #update the solutions in the DB
        with open("C:\Users\Laptop\Desktop\MileStones\MileStone2\\reportSignatureSearch.txt", 'w') as reportFile:

            self.suspicions_files.append(str(num_of_scannings_files))
            self.suspicions_files.append(str(num_of_suspicions_files))
            send_string = ",".join(self.suspicions_files)
            reportFile.writelines(send_string)


pathes_file = open("C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt",'r')
pathes = pathes_file.read().splitlines()
pathSignature = pathes[len(pathes) - 1]
pathesObject = searchSignature(pathSignature)