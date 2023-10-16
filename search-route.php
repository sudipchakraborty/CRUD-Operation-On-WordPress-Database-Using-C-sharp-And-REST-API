<?php
add_action('rest_api_init','universityRegisterSearch');

function universityRegisterSearch()
{
    register_rest_route('university/v1','search',array(

        'methods'=>'GET',
        'callback'=>'universitySearchResults'
    ));
}
/* ___________________________________________________________________________________________________________________________________*/
function universitySearchResults() 
{
  
  /*  da_emp_update_call();

*/
    return 'it is your new rout222';
}


/* ___________________________________________________________________________________________________________________________________*/
function create_table() 
{
    global $wpdb;
    $charset_collate = $wpdb->get_charset_collate();
    $table_name = $wpdb->prefix . 'ems';
    $sql = "DROP TABLE IF EXISTS $table_name;
            CREATE TABLE $table_name(
            id mediumint(11) NOT NULL AUTO_INCREMENT,
            emp_id varchar(50) NOT NULL,
            emp_name varchar (250) NOT NULL,
            emp_email varchar (250) NOT NULL,
            emp_dept varchar (250) NOT NULL,
            PRIMARY KEY id(id)
            )$charset_collate;";
    require_once(ABSPATH . 'wp-admin/includes/upgrade.php');
    dbDelta($sql);
}

/* ___________________________________________________________________________________________________________________________________*/
function da_ems_add_callback()
{
    global $wpdb;
    $table_name = $wpdb->prefix . 'ems';
    $msg = '';

        $wpdb->insert("$table_name", [
            "emp_id" => '557',
            'emp_name' => 'jkhkhkjh',
            'emp_email' =>'jkljkljlj',
            'emp_dept' => 'kljljljlj'
        ]);


        if ($wpdb->insert_id > 0) {
            $msg = "Saved Successfully";
        } else {
            $msg = "Failed to save data";
        }
}
/* ___________________________________________________________________________________________________________________________________*/
function da_emp_update_call()
{
    global $wpdb;
    $table_name = $wpdb->prefix . 'ems';
    $msg = '';

    $_REQUEST = array(      
        "emp_id"=>"557", 
        "emp_name"=>"100",
        "emp_email"=>"120", 
        "emp_dept"=>"110", 
        "id"=>1);

    $id = '1';
    if (isset($_REQUEST['update'])) {
        if (!empty($id)) {
            $wpdb->update("$table_name", ["emp_id" => $_REQUEST['emp_id'], 'emp_name' => $_REQUEST['emp_name'], 'emp_email' => $_REQUEST['emp_email'], 'emp_dept' => $_REQUEST['emp_dept']], ["id" => $_REQUEST['id']]);
            $msg = 'Data updated';
        }
    }   
     
}
/* ___________________________________________________________________________________________________________________________________*/













/* ___________________________________________________________________________________________________________________________________*/
