import psutil
import wmi
import hashlib
import subprocess
import pythoncom

class Heurisitic_process():

    p_name = None

    def __init__(self, p_name):
        self.p_name = p_name
        self.result_if_malware_way1 = False
        self.result_if_malware_way2 = False
        self.result_if_malware_way3 = False
        self.final_notice = self.check_if_malware()

    def run_command(self, cmd):  # the cmd
        return subprocess.Popen(cmd, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)\
            .communicate()


    def get_pid(self):
        """
        Get the name of a running project and return his PID
        :return: the pid of the process
        """
        c = wmi.WMI()
        for process in c.Win32_Process():
            try:
                p = psutil.Process(int(process.ProcessId))
                if self.p_name in process.commandLine:
                    self.ProcessID = p.pid
            except:
                pass

    def check_if_malware_accordingToAccessFiles(self):
        """
        Check if the process get into a system file
        :return:if it is get to a system file or not
        """

        pid = self.ProcessID

        output_of_files = self.run_command("C:\Users\\ajr12\handle -p %s" % pid)

        # path of system files which normal process must'nt get there

        suspicion_library = "System32"

        if suspicion_library in output_of_files[0]:
            return True
        return False

    def check_if_malware_according_to_keys(self):
        """
        check if the process is getting into forbidden registr keys(HKU,HKCC)
        :return: if he does True and if he doesn't False
        """
        pid = self.ProcessID

        output_of_files = self.run_command("C:\Users\\ajr12\handle -a -p %s" % pid)

        #keys which normal process will never get to
        forbidden_keys = ['HKU', 'HKCC']
        for i in forbidden_keys:
            if i in output_of_files[0]:
                return True
        return False





    def check_if_malware_according_to_ip(self):
        """
        Check if the process have an open port
        :return: if the process is a malware
        """

        pid = self.ProcessID

        # command in cmd which reply if the process have an open port
        output_netstat = self.run_command("netstat -a -o")  # get the port that the client communicate with

        if str(pid) in output_netstat[0]:
            string_netstat = output_netstat[0]  # play with the string until he gets the port
            list_neststat = string_netstat.split(':')

            for i in list_neststat:
                if str(pid) in i:
                    details = i
                    break

            remote_port = ""
            for i in details:
                if not i == ' ':
                    remote_port += i
                else:
                    break
            if not(remote_port == "http" or remote_port == "https"):
                return True
            else:
                return False
        else:
            return False



    '''
    def get_number_to_autorun(self):
        """
        :return: The numbers of the paths in the autorun key
        """
        c = wmi.WMI()
        autorun_number = 0
        for i in c.Win32_StartupCommand():
            autorun_number += 1
        return autorun_number

    '''

    def check_if_malware(self):
        """
        The main function which combine all the testes
        :return: return the signature of the process in case it is a malware
        """

        self.get_pid()
        print '-1'
        # if there is no pid means that the program is'nt running
        print "L"
        print "L2"
        try:
            if not self.ProcessID:
                return False
        except:# if there is a kind of bug the program return it doesn't a virus
            return False
        print '0'
        # check by socket communicate
        self.result_if_malware_way1 = self.check_if_malware_according_to_ip()
        print '1'
        # check by access to System32
        self.result_if_malware_way2 = self.check_if_malware_accordingToAccessFiles()
        # check by access to forbidden regstries
        self.result_if_malware_way3 =  self.check_if_malware_according_to_keys()
        print '3'

        print "Open ports:%s"%self.result_if_malware_way1
        print "Go into System32:%s"%self.result_if_malware_way2
        print "Use forbidden regstries:%s"%self.result_if_malware_way3


        # return true if even one condition is on
        if self.result_if_malware_way1 or self.result_if_malware_way2 or self.result_if_malware_way3:
            return True
        return False