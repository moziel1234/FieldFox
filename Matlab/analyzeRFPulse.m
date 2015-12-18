function [ output_args ] = analyzeRFPulse( path_to_folder )
%ANALYZERFPULSE Summary of this function goes here
%   Detailed explanation goes here
    rf_data = folderToObject(path_to_folder);
    pulse_data = pulseMeter([path_to_folder,'\\log.txt']);
    
    % Convert pulse time to milli (same format as rf)    
    epoch_time = pulse_data.first_meas_epoch;
    first_sample_mili = convertEpochToMili(epoch_time);
    time_pulse = (pulse_data.time_full * 1000) + first_sample_mili;
    pulse_data.time_in_mili = time_pulse(time_pulse>=rf_data.times(1) & time_pulse<=rf_data.times(end));
    pulse_data.smoothed_data_relevant =  pulse_data.smoothed_data(time_pulse>=rf_data.times(1) & time_pulse<=rf_data.times(end));
    
    
    figure; plot(rf_data.times,rf_data.amp_db,'b'); 
    figure; plot(pulse_data.time_in_mili, pulse_data.smoothed_data_relevant ,'r');

end

function time_mili = convertEpochToMili(epoch_time)
    time_reference = datenum('1970', 'yyyy'); 
    time_matlab = time_reference + epoch_time / 8.64e7;
    time_matlab_string = datestr(time_matlab, 'HHMMSSFFF');
    time_mili = FileNameToMili(time_matlab_string);
end