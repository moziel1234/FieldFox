function [ ret_obj ] = folderToObject( folder_name )
%FOLDERTOOBJECT Summary of this function goes here
%   Detailed explanation goes here
    plotC = 1;
    
    useRegularFunction = 1;
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
            if ind==1
                times = zeros(size(S));
                amp_db = zeros(length(S),length(data.freq));
                phase_deg = amp_db;
            end
            times(ind) = FileNameToMili(file_name{1});
            data = read(rfdata.data,[folder_name,'\\',file_name{1}]);
            freqs = data.freq/1e6;
            
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
            [ freqs, amp, phs ] = readS21FromS2pFile([folder_name,'\\',file_name{1}] );
            file_time = FileNameToMili(file_name{1});
            times = [times , linspace(file_time-sweepTime*1000,file_time,pointsNum)];
            amp_db = [amp_db, amp];
            phase_deg = [phase_deg ,phs];
        end
        
    end
    time_sec = (times-times(1))/1000;
    if plotC
        close all;
        set(0, 'DefaulttextInterpreter', 'none');
        amp_fig=figure; plot(time_sec,amp_db); title(folder_name); 
        xlabel('Time [sec]'); ylabel('Amplitude [db]'); legend(cellstr(strcat(num2str(freqs),' MHz')));
        phs_fig=figure; plot(time_sec,phase_deg); title(folder_name);
        xlabel('Time [sec]'); ylabel('Phase [deg]'); legend(cellstr(strcat(num2str(freqs),' MHz')));
        savefig(amp_fig,[folder_name,'\amp_fig']);
        savefig(phs_fig,[folder_name,'\phs_fig']);
    end
    save([folder_name,'\data.mat'],'time_sec','amp_db','phase_deg','freqs');
    ret_obj.time_sec=time_sec;
    ret_obj.amp_db=amp_db;
    ret_obj.phase_deg=phase_deg;
    ret_obj.freqs=freqs;
end

function ret_time = FileNameToMili(file_name)
    % 1045578098_0.s2p
    % hhmmssfff
    hours = str2double(file_name(1:2)) * 60 * 60 * 1000;
    minutes = str2double(file_name(3:4)) * 60 * 1000;
    seconds = str2double(file_name(5:6)) * 1000;
    mili = str2double(file_name(7:9));
    ret_time = hours + minutes + seconds + mili;
end

