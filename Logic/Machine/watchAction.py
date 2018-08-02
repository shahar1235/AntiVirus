import os
import time
import ClientvirusTransfer


class WatchByPath:

    path_to_watch = None

    def __init__(self, path_to_watch):
        self.path_to_watch = path_to_watch
        self.watch_action()
        self.UpToDatePath = ""

    def watch_action(self):
        """
        action which get a path and check for new folders in the path and in the folders of the path
        after it found, it send it to the checking
        :return:
        """
        files_in_path = []
        files_in_path.append(self.path_to_watch)
        before = []
        before.append(dict([(f, None) for f in os.listdir(self.path_to_watch)]))

        # save the folders
        for files in os.listdir(self.path_to_watch):
            files = self.path_to_watch + '\\' + files
            if not ('.' in files):
                files_in_path.append(files)
                # the directory/folder i want to research virus
                before.append(dict([(f, None) for f in os.listdir(files)]))

        # pass every time and check for changes
        while 1:
            time.sleep(5)
            # check folder by folder if there is a change
            for folder_num in range(len(files_in_path)):
                try:

                    after = dict([(f, None) for f in os.listdir(files_in_path[folder_num])])
                    added = [f for f in after if not f in before[folder_num]]
                    if added:
                        print "Added: ", ", ".join(added)
                        for i in added:
                            self.osWalkInNewFile(files_in_path[folder_num], i)
                            before[folder_num] = after
                            new_object = files_in_path[folder_num] + "\\" + i
                            files_in_path.append(new_object)
                            try:
                                before.append(dict([(f, None) for f in os.listdir(new_object)]))
                            except:
                                pass
                    # scratch the variable
                    added = ""
                except:
                    pass


    def osWalkInNewFile(self, path, file_name):
        """
         get a file and send all the  .exe files to the sand box
        :param path: path of the folder of the suspicions files
        :param file_name: name of the suspicion file
        """
        # update the path to the report
        self.UpToDatePath = path + "\\" + file_name
        if ".exe" in file_name:
            print 'g'
            # do your action with the client
            path_of_malware = path + "\\" + file_name
            self.prepare_send_sandbox(path_of_malware)
        else:
            path_total = path + "\\" + file_name
            for root, dirs, files in os.walk(r"%s" % path_total):
                for i in files:
                    if ".exe" in i:
                        path_of_malware = root + "\\" + i
                        self.UpToDatePath = path_of_malware
                        self.prepare_send_sandbox(path_of_malware)

    def prepare_send_sandbox(self, path_of_malware):
        """
        send to the sand box
        :param path_of_malware: the path of the suspicion file
        :return: if the file is a virus or not!!
        """
        av_report = ClientvirusTransfer.checkForNewDownLoad(path_of_malware)
        # the role of the try and except is to notice if the error is signature because than "arr_answer" wont be exist
        # and PyCharm will send error

        try:
            if av_report.total_answer:
                report_file = open("C:\Users\Laptop\Desktop\MileStones\MileStone2\\report_virus.txt", 'w')
                report_file.writelines('New virus, location: "%s", Open port: %s, Get System32: %s, '
                                       "Get resitry: %s" % (self.UpToDatePath, av_report.arr_answers[1],
                                                              av_report.arr_answers[2], av_report.arr_answers[3]))
                report_file.close()

            else:

                report_file = open("C:\Users\Laptop\Desktop\MileStones\MileStone2\\report_virus.txt", 'w')
                report_file.writelines('clean, location: %s ' % self.UpToDatePath)

                report_file.close()


        except:
            # just if the checking based on the DB because than the categories of the virus won't appear
            report_file = open("C:\Users\Laptop\Desktop\MileStones\MileStone2\\report_virus.txt", 'w')
            report_file.writelines('New virus, location: "%s" Based on the signature DB'
                                   % self.UpToDatePath)
            report_file.close()
        time.sleep(6)

pathes_file = open("C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt",'r')
pathes = pathes_file.read().splitlines()
pathWatch = pathes[len(pathes) -1]
a = WatchByPath(pathWatch)



