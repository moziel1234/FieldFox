function [ ret_obj ] = folderToObject( folder_name )
%FOLDERTOOBJECT Summary of this function goes here
%   Detailed explanation goes here
    plotC = 1;
    smooth_time = 0.5; %seconds
    useRegularFunction = 1;
    s_param = 'S21';
    %check if NAParam.dat exist
    if exist([folder_name,'\\NAParam.dat'], 'file') == 2
        %if exist read file and get the NA params.
        fid = fopen([folder_name,'\\NAParam.dat']);
        tline = fgetl(fid);
        while ischar(tline)
            %Here I am actually define new variables. (So ugly....)
            eval([tline,';']);
            tline = fgetl(fid);
        end
        fclose(fid);
        
        %Assume spanFreq will always exist
        if spanFreq==0
            useRegularFunction = 0;
        end
            
    end
   
    D = dir([folder_name,'\*.s2p']);
    S = sort({D.name});
    ind = 0;
    
    for file_name = S
        ind = ind +1;
        if useRegularFunction
            
            data = read(rfdata.data,[folder_name,'\\',file_name{1}]);
            freqs = data.freq/1e6;
            if ind==1
                times = zeros(size(S));
                amp_db = zeros(length(S),length(data.freq));
                phase_deg = amp_db;
            end     
            times(ind) = FileNameToMili(file_name{1});
            % should be 21
            amp_db(ind,1:length(data.freq))=20*log10(abs(data.S_Parameters(2,1,:))); 
            phase_at_vec = reshape(data.S_Parameters(2,1,:),1, []);
            phase_deg(ind,1:length(data.freq)) = 180/pi*phase(phase_at_vec);
        else
            if ind==1
                times = [];
                amp_db = [];
                phase_deg = [];
            end
            % Here assume that there is only one freq
            [ freqs, amp, phs ] = readS21FromS2pFile([folder_name,'\\',file_name{1}], s_param);
            file_time = FileNameToMili(file_name{1});
            times = [times , linspace(file_time-sweepTime*1000,file_time,pointsNum)];
            amp_db = [amp_db, amp];
            phase_deg = [phase_deg ,phs];
        end
        
    end
    time_sec = (times-times(1))/1000;
    % amp_db_homo = amp_db - smooth(amp_db, find(time_sec>smooth_time,1))';
    % phase_deg_homo = phase_deg - smooth(phase_deg, find(time_sec>smooth_time,1))';
    if plotC
        close all;
        set(0, 'DefaulttextInterpreter', 'none');
        amp_fig=figure; plot(time_sec,amp_db); title(folder_name); 
        xlabel('Time [sec]'); ylabel('Amplitude [db]'); legend(cellstr(strcat(num2str(freqs),' MHz')));
        phs_fig=figure; plot(time_sec,phase_deg); title(folder_name);
        xlabel('Time [sec]'); ylabel('Phase [deg]'); legend(cellstr(strcat(num2str(freqs),' MHz')));
        savefig(amp_fig,[folder_name,'\amp_fig']);
        savefig(phs_fig,[folder_name,'\phs_fig']);
        
        % figure; plot(time_sec,-25*amp_db_homo./(amp_db_homo-1));
    end
    save([folder_name,'\data.mat'],'time_sec','amp_db','phase_deg','freqs','times');
    ret_obj.time_sec=time_sec;
    ret_obj.times=times;
    ret_obj.amp_db=amp_db;
    % ret_obj.amp_db_homog=-25*amp_db_homo./(amp_db_homo-1);
    ret_obj.phase_deg=phase_deg;
    % ret_obj.phase_deg_homo=phase_deg_homo;
    ret_obj.freqs=freqs;
end


